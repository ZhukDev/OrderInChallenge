namespace OrderInChallenge.Commands.Order.Create
{
    public class CreateOrderResult
    {
        public CreateOrderResult(bool created)
        {
            Created = created;
        }

        public bool Created { get; set; }
    }
}
