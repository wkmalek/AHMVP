namespace AHWForm.Models
{
    public class ApiDataObject
    {
        public object data { get; set; }
        public string PublicKey { get; set; }
        public string HashedUserName { get; set; }
        public string HashedPassword { get; set; }
    }
}