using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskUsar.Core.Services
{
    /// <summary>
    /// Messages file actions interface
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Opened json file with messages collection
        /// </summary>
        /// <param name="filename">Selected file name</param>
        /// <returns>Deserialized message list</returns>
        List<Message> Open(string filename);

        /// <summary>
        /// Saving a message list to json format file
        /// </summary>
        /// <param name="filename">Some file name</param>
        /// <param name="messagesList">Your messsage list for saving</param>
        void Save(string filename, List<Message> messagesList);
    }
}
