namespace MotorcycleRental.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static int GetUserId(this HttpContext context)
        {
            return int.Parse(context.User.Claims.First(x => x.Type == "idUser").Value);
        }

        public static int GetCustomerId(this HttpContext context)
        {
            return int.Parse(context.User.Claims.First(x => x.Type == "idCustomer").Value);
        }

    }
}
