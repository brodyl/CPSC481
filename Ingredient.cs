public class Ingredient {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; } = false;
}