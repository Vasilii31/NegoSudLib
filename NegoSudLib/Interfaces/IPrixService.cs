using NegoSudLib.DAO;
using NegoSudLib.DTO;

namespace NegoSudLib.Interfaces
{
    public interface IPrixService
    {
        Task<PrixAchat?> PostPrixAchat(PrixAchat prix);
    }
}