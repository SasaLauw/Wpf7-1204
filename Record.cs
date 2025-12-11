namespace WpfApp5
{
    // ✅ 一筆選課紀錄
    public class Record
    {
        // 學生
        public Student Student { get; set; }

        // 課程
        public Course Course { get; set; }

        // 選課時間（可要可不要）
        public string SelectTime { get; set; }
    }
}
