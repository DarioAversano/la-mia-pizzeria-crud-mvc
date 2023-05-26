namespace LaMiaPizzeria.Models
{
    public class PizzaCategoryForm
    {

        public PizzaModel Pizza { get; set; }
        public List<PizzaCategory>? PizzaCategories { get; set; }

        public PizzaCategoryForm(List<PizzaCategory>? pizzaCategories)
        {
            this.Pizza = new PizzaModel();
            this.PizzaCategories = pizzaCategories;
        }
    }
}
