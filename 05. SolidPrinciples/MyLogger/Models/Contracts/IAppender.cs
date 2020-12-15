using MyLogger.Models.Enumerator;

namespace MyLogger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        long MessageAppended { get; }

        void AppendError(IError error);
    }
}
