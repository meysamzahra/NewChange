namespace Mc2.Framework.Domain.Utils;

public interface IClock
{
    DateTime Now();
    void SetNow(DateTime date);
}