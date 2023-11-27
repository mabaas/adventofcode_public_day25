using SeaCucumber.Models;

namespace SeaCucumber.Services.Interfaces
{
    public interface IHerdService
    {
        public Seabed EastMovingHerd(Seabed seabed);

        public Seabed SouthMovingHerd(Seabed seabed);
    }
}