namespace SensxWebApi.Helper
{
    public static class HelperMethods
    {
        public static string Reverse(this string input)
        {
            if(input != null)
            {
                char[] charArray = input.ToCharArray();
                Array.Reverse(charArray);

                return new string(charArray);
            }
            else
            {
                throw new ArgumentNullException("input");
            }
        }
    }
}
