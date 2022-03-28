
namespace TestTaskUsar.Core.Services
{
    /// <summary>
    /// System interaction for workning with file
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Save/open file operation result message showing
        /// </summary>
        /// <param name="message">Input message</param>
        void ShowMessage(string message);   

        /// <summary>
        /// Path to creation file
        /// </summary>
        string FilePath { get; set; } 

        /// <summary>
        /// Open some file dialog method
        /// </summary>
        /// <returns>OPeration result</returns>
        bool OpenFileDialog();  

        /// <summary>
        /// save some file dialog method
        /// </summary>
        /// <returns>Operation result</returns>
        bool SaveFileDialog();
    }
}
