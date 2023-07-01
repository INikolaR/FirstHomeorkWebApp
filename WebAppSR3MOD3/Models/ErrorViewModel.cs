namespace WebAppSR3MOD3.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// The id of request.
        /// </summary>
        public string? RequestId { get; set; }
        /// <summary>
        /// Shows the id of request.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}