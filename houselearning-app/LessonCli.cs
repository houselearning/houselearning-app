using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace houselearning_app
{
    [DataContract]
    public sealed class CourseRecord
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "gradeLabel")]
        public string GradeLabel { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    public sealed class LessonCliForm : Form
    {
        private const string CatalogUrl = "https://www.houselearning.org/home/course-catalog.json";
        private readonly TextBox commandInput;
        private readonly RichTextBox output;
        private readonly Label connectionStatus;
        private List<CourseRecord> catalog = new List<CourseRecord>();

        public LessonCliForm()
        {
            Text = "HouseLearning Lesson CLI";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new System.Drawing.Size(700, 500);
            Size = new System.Drawing.Size(820, 620);

            var title = new Label
            {
                Dock = DockStyle.Top,
                Height = 46,
                Padding = new Padding(16, 12, 8, 0),
                Font = new System.Drawing.Font("Segoe UI", 15, System.Drawing.FontStyle.Bold),
                Text = "Lesson catalog command line"
            };
            connectionStatus = new Label
            {
                Dock = DockStyle.Top,
                Height = 28,
                Padding = new Padding(18, 4, 8, 0),
                Text = "Connecting to the HouseLearning course catalog..."
            };
            output = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                DetectUrls = true,
                Font = new System.Drawing.Font("Consolas", 10),
                BackColor = System.Drawing.Color.FromArgb(23, 38, 49),
                ForeColor = System.Drawing.Color.FromArgb(233, 241, 239),
                BorderStyle = BorderStyle.None,
                WordWrap = false
            };

            var commandBar = new Panel { Dock = DockStyle.Bottom, Height = 52, Padding = new Padding(12) };
            commandInput = new TextBox { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Consolas", 10) };
            commandInput.KeyDown += (sender, args) =>
            {
                if (args.KeyCode != Keys.Enter) return;
                args.SuppressKeyPress = true;
                RunCommand();
            };
            var runButton = new Button { Dock = DockStyle.Right, Width = 96, Text = "Run" };
            runButton.Click += (sender, args) => RunCommand();
            commandBar.Controls.Add(commandInput);
            commandBar.Controls.Add(runButton);

            Controls.Add(output);
            Controls.Add(commandBar);
            Controls.Add(connectionStatus);
            Controls.Add(title);
            Shown += async (sender, args) => await LoadCatalogAsync();
        }

        private async Task LoadCatalogAsync()
        {
            try
            {
                using (var client = new HttpClient())
                using (var response = await client.GetAsync(CatalogUrl))
                {
                    response.EnsureSuccessStatusCode();
                    var bytes = await response.Content.ReadAsByteArrayAsync();
                    var serializer = new DataContractJsonSerializer(typeof(List<CourseRecord>));
                    using (var stream = new MemoryStream(bytes))
                    {
                        catalog = (List<CourseRecord>)serializer.ReadObject(stream);
                    }
                }

                ValidateCatalog();
                connectionStatus.Text = String.Format("Connected: {0} Math and Science lessons. Try help.", catalog.Count);
                WriteLine("HouseLearning Lesson CLI");
                WriteLine("Type help for commands. Catalog destinations open on HouseLearning.org.");
            }
            catch (Exception error)
            {
                connectionStatus.Text = "Course catalog unavailable.";
                WriteLine("Could not load the live catalog: " + error.Message);
                WriteLine("Check your connection and retry by reopening the Lesson CLI.");
            }
        }

        private void ValidateCatalog()
        {
            if (catalog == null || catalog.Count == 0)
                throw new InvalidDataException("The course catalog is empty.");

            if (catalog.Any(course => course == null
                || (course.Subject != "math" && course.Subject != "science")
                || course.Grade < 0 || course.Grade > 12
                || String.IsNullOrWhiteSpace(course.Title)
                || String.IsNullOrWhiteSpace(course.Href)
                || !course.Href.StartsWith("/home/", StringComparison.Ordinal)))
                throw new InvalidDataException("The course catalog contains an invalid lesson record.");
        }

        private void RunCommand()
        {
            var tokens = (commandInput.Text ?? String.Empty)
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            commandInput.Clear();
            if (tokens.Length == 0) return;

            var command = tokens[0].ToLowerInvariant();
            if (command == "help")
            {
                WriteLine("Commands:");
                WriteLine("  search <words> [--subject math|science] [--grade K|1-12]");
                WriteLine("  list [--subject math|science] [--grade K|1-12]");
                WriteLine("  check");
                WriteLine("  help");
                WriteLine("Examples: search fractions --subject math --grade 4");
                return;
            }

            if (catalog.Count == 0)
            {
                WriteLine("The catalog is not available yet; retry after the connection status updates.");
                return;
            }

            if (command == "check")
            {
                var missing = (from subject in new[] { "math", "science" }
                               from grade in Enumerable.Range(0, 13)
                               where !catalog.Any(course => course.Subject == subject && course.Grade == grade)
                               select subject + " grade " + (grade == 0 ? "K" : grade.ToString())).ToList();
                WriteLine(missing.Count == 0
                    ? String.Format("Catalog check passed: all 26 subject/grade groups are present ({0} lessons).", catalog.Count)
                    : "Catalog is missing: " + String.Join(", ", missing));
                return;
            }

            if (command != "list" && command != "search")
            {
                WriteLine("Unknown command. Type help for available commands.");
                return;
            }

            var subjectFilter = String.Empty;
            int? gradeFilter = null;
            var queryWords = new List<string>();
            for (var index = 1; index < tokens.Length; index++)
            {
                if (tokens[index] == "--subject" && index + 1 < tokens.Length)
                {
                    subjectFilter = tokens[++index].ToLowerInvariant();
                }
                else if (tokens[index] == "--grade" && index + 1 < tokens.Length)
                {
                    var gradeValue = tokens[++index].ToUpperInvariant();
                    if (gradeValue != "K")
                    {
                        int parsedGrade;
                        if (!Int32.TryParse(gradeValue, out parsedGrade) || parsedGrade < 1 || parsedGrade > 12)
                        {
                            WriteLine("Grade must be K or an integer from 1 through 12.");
                            return;
                        }
                        gradeFilter = parsedGrade;
                    }
                    else
                    {
                        gradeFilter = 0;
                    }
                }
                else
                {
                    queryWords.Add(tokens[index]);
                }
            }

            if (!String.IsNullOrEmpty(subjectFilter) && subjectFilter != "math" && subjectFilter != "science")
            {
                WriteLine("Subject must be math or science.");
                return;
            }
            if (command == "search" && queryWords.Count == 0)
            {
                WriteLine("Provide search words, for example: search cells --subject science --grade 7");
                return;
            }

            var terms = queryWords.Select(word => word.ToLowerInvariant()).ToArray();
            var results = catalog.Where(course =>
                (String.IsNullOrEmpty(subjectFilter) || course.Subject == subjectFilter)
                && (!gradeFilter.HasValue || course.Grade == gradeFilter.Value)
                && terms.All(term => (course.Title + " " + course.Subject + " " + course.GradeLabel)
                    .IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0))
                .OrderBy(course => course.Grade)
                .ThenBy(course => course.Subject)
                .ThenBy(course => course.Title)
                .ToList();

            WriteLine(String.Format("{0} matching lessons:", results.Count));
            foreach (var course in results.Take(50))
            {
                WriteLine(String.Format("[{0} {1}] {2}  https://www.houselearning.org{3}",
                    course.GradeLabel, course.Subject, course.Title, course.Href));
            }
            if (results.Count > 50) WriteLine("Showing first 50; narrow the search for more specific results.");
        }

        private void WriteLine(string text)
        {
            output.AppendText(text + Environment.NewLine);
            output.SelectionStart = output.TextLength;
            output.ScrollToCaret();
        }
    }
}