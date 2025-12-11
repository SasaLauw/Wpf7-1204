namespace WpfApp5
{
    public class Course
    {
        public string CourseName { get; set; }
        public int Point { get; set; }
        public Teacher Tutor { get; set; }

        public override string ToString()
        {
            return CourseName;
        }
    }
}
