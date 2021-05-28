using Microsoft.EntityFrameworkCore;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public interface IAirplaneService
    {
        Task<IEnumerable<Airplane>> GetAirplanes();
        Task AddAirplane(Airplane airplane);
        Task<IEnumerable<Airplane>> GetAirplanesOrderedByCapacity();
        Task<IEnumerable<Airplane>> GetAirplanesByEconomyClassCapacity(int capacity);
        Task<IEnumerable<Airplane>> GetAirplanesByBusinessClassCapacity(int capacity);
        Task<IEnumerable<Airplane>> GetAirplanesByFirstClassCapacity(int capacity);
        Task<bool> IsAirplaneExist(int index);
        Task<bool> IsPossibleToDeleteOrUpdate(int index);
        Task changeAirplaneData(int index, Airplane airplane);
        Task DeleteAirplane(int index);
    }

    public class AirplaneService : IAirplaneService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<IEnumerable<Airplane>> GetAirplanes()
        {
            return await _context.Airplanes.ToListAsync();
        }

        public async Task AddAirplane(Airplane airplane)
        {
            _context.Airplanes.Add(airplane);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Airplane>> GetAirplanesOrderedByCapacity()
        {
            var airplanes = await(from t in _context.Airplanes
                                  orderby t.economyClassCapacity + t.firstClassCapacity + t.businessClassCapacity descending
                                  select t).ToListAsync();
            return airplanes;
        }

        public async Task<IEnumerable<Airplane>> GetAirplanesByEconomyClassCapacity(int capacity)
        {
            var airplanes = await _context.Airplanes
                                .Where(a => a.economyClassCapacity >= capacity)
                                .OrderBy(a => a.economyClassCapacity).ToListAsync();

            return airplanes;
        }

        public async Task<IEnumerable<Airplane>> GetAirplanesByBusinessClassCapacity(int capacity)
        {
            var airplanes = await _context.Airplanes
                              .Where(a => a.businessClassCapacity >= capacity)
                              .OrderBy(a => a.businessClassCapacity).ToListAsync();

            return airplanes;
        }

        public async Task<IEnumerable<Airplane>> GetAirplanesByFirstClassCapacity(int capacity)
        {
            var airplanes = await _context.Airplanes
                              .Where(a => a.firstClassCapacity >= capacity)
                              .OrderBy(a => a.firstClassCapacity).ToListAsync();

            return airplanes;
        }

        public async Task<bool> IsAirplaneExist(int index)
        {
            var airplanes = await _context.Airplanes
                                .Where(a => a.airplaneId == index).ToListAsync();

            return airplanes.Any();
        }

        public async Task<bool> IsPossibleToDeleteOrUpdate(int index)
        {
            var airplanes = await _context.Flights
                                    .Where(f => f.airplaneId == index).ToListAsync();

            return !airplanes.Any();
        }

        public async Task changeAirplaneData(int index, Airplane airplane)
        {
            var tempAirplane = await FindAirplaneById(index);

            tempAirplane.airplaneId = index;
            tempAirplane.code = airplane.code;
            tempAirplane.shortcut = airplane.shortcut;
            tempAirplane.fullName = airplane.fullName;
            tempAirplane.economyClassCapacity = airplane.economyClassCapacity;
            tempAirplane.businessClassCapacity = airplane.businessClassCapacity;
            tempAirplane.firstClassCapacity = airplane.firstClassCapacity;
            tempAirplane.range = airplane.range;
            tempAirplane.productionYear = airplane.productionYear;
            tempAirplane.manufacturer = airplane.manufacturer;
            tempAirplane.hoursFlown = airplane.hoursFlown;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAirplane(int index)
        {

            var airplane = await FindAirplaneById(index);

            _context.Airplanes.Attach(airplane);
            _context.Entry(airplane).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Airplane> FindAirplaneById(int id)
        {
            return await _context.Airplanes
                                .Where(a => a.airplaneId == id).FirstAsync();
        }

    }
}
