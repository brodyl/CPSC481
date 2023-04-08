public class MenuItem {
        public int ID { get; set; }
        public string? category { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? size { get; set; }
        public string? saltLevel { get; set; }
        public string? dippingSauces { get; set; }
        public string? image { get; set; }
        public string? imageSm { get; set; }
        public string? imageLg { get; set; }
        public string? description { get; set; }
        public int? Calories { get; set; }


        //Variables to represent combo items assuming the category is "combo"
        public MenuItem? side { get; set; }
        public MenuItem? drink { get; set; }
        public List<string>? sauces { get; set; }


        public string? tags { get; set; }

        public List<Ingredient>? Ingredients { get; set; }
}