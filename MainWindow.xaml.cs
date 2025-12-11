using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public ObservableCollection<Course> AllCourses { get; set; }
        public ObservableCollection<Course> SelectedCourses { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Students = new ObservableCollection<Student>();
            Teachers = new ObservableCollection<Teacher>();
            AllCourses = new ObservableCollection<Course>();
            SelectedCourses = new ObservableCollection<Course>();

            LoadData();

            StudentComboBox.ItemsSource = Students;
            TeacherTreeView.ItemsSource = Teachers;
            CourseListBox.ItemsSource = AllCourses;
            SelectedCourseListBox.ItemsSource = SelectedCourses;
        }

        private void LoadData()
        {
            Students.Add(new Student { Name = "鄧紫棋" });
            Students.Add(new Student { Name = "王俊凱" });

            Teacher t1 = new Teacher { TeacherName = "蔡老師" };
            Teacher t2 = new Teacher { TeacherName = "陳老師" };

            Course c1 = new Course { CourseName = "視窗程式設計", Point = 3, Tutor = t1 };
            Course c2 = new Course { CourseName = "資料結構", Point = 3, Tutor = t1 };
            Course c3 = new Course { CourseName = "網頁設計", Point = 2, Tutor = t2 };

            t1.TeachingCourses.Add(c1);
            t1.TeachingCourses.Add(c2);
            t2.TeachingCourses.Add(c3);

            Teachers.Add(t1);
            Teachers.Add(t2);

            AllCourses.Add(c1);
            AllCourses.Add(c2);
            AllCourses.Add(c3);
        }

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            Course selected = null;

            if (CourseListBox.SelectedItem is Course c1)
                selected = c1;

            if (TeacherTreeView.SelectedItem is Course c2)
                selected = c2;

            if (selected == null)
            {
                MessageBox.Show("請先選課！");
                return;
            }

            if (!SelectedCourses.Contains(selected))
            {
                SelectedCourses.Add(selected);
                StatusTextBlock.Text = "已選：" + selected.CourseName;
            }
            else
            {
                MessageBox.Show("此課程已選過！");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCourseListBox.SelectedItem is Course c)
            {
                SelectedCourses.Remove(c);
                StatusTextBlock.Text = "已退選：" + c.CourseName;
            }
            else
            {
                MessageBox.Show("請先選擇退選課程！");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"目前共選 {SelectedCourses.Count} 門課");
        }
    }
}
