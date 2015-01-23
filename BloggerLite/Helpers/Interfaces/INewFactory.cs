namespace BloggerLite.Helpers.Interfaces
{
    public interface INewFactory<T>
    {
        /// <summary>
        /// Returns a new instance of T.
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// Creates an instance of T with the specified parameters.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param> 
        /// <returns></returns>
        T Get(string param1, string param2);

        T Get(string param1);
    }
}
