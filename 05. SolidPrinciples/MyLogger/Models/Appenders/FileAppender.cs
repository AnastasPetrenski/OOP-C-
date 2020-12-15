using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;

namespace MyLogger.Models.Appenders
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

        public long MessageAppended { get; private set; }

        public void AppendError(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);
            this.MessageAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {typeof(FileAppender)}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessageAppended}, File size: {this.File.Size}";
        }
    }
}
