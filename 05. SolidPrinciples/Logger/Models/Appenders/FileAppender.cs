using Logger.Models.Contracts;
using Logger.Models.Enumerators;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public long MessegesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedMessege = this.File.Write(this.Layout, error);
            
            System.IO.File.AppendAllText(this.File.Path, formattedMessege);
            this.MessegesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {typeof(FileAppender)}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessegesAppended}, File size: {this.File.Size}";
        }
    }
}
