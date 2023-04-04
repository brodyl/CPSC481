public class MenuItem {
        public string? category { get; set; }
        public int ID { get; set; }
        public string? name { get; set; }
        public int price { get; set; }
        public string? image { get; set; }
        public string? tags { get; set; }
        public List<Ingredients> ingredients { get; set; }
}