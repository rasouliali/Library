using Library.Application.UseCases.Commons.Bases;
using MediatR;

namespace Library.Application.UseCases.Borrowings.Commands.Update
{
    public class UpdateBorrowingCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public int UpddaterUserId { get; private set; }
        public bool IsExtend { get; set; }
        public bool IsReturn { get; set; }

        public void SetUpddaterUserId(int upddaterUserId)
        {
            UpddaterUserId = upddaterUserId;
        }
    }
}