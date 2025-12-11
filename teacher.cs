using System.Collections.ObjectModel;

namespace WpfApp5
{
    public class Teacher
    {
        public string TeacherName { get; set; }

        public ObservableCollection<Course> TeachingCourses { get; set; }
            = new ObservableCollection<Course>();

        public override string ToString()
        {
            return TeacherName;
        }
    }
}
