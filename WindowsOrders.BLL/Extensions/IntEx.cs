namespace WindowsOrders.BLL.Extensions
{
    public static class IntEx
    {
        public static int ToInt(this string str)
        {
            var ret = 0;
            if (!int.TryParse(str, out ret))
            {
                ret = 0;
            }
            return ret; 
        }
    }
}
