namespace InnatAPP.Application.CQRS.Reviews.Commands
{
    public class ReviewUpdateCommand : ReviewCommand
    {
        public Guid Id { get; set; }
    }
}