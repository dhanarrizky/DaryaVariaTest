public class ChartViewModel
{
    public string[] Labels { get; set; }
    public List<Dataset> Datasets { get; set; }

    public class Dataset
    {
        public string Label { get; set; } 
        public int[] Data { get; set; }
        public string BackgroundColor { get; set; }
    }
}
