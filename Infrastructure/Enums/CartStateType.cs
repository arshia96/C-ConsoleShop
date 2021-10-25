using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Enums
{
    public enum CartStateType
    {
        CreatedCart,
        CartHadRemovedItem,
        InstallmentCart,
        FullPaidCart
    }
}