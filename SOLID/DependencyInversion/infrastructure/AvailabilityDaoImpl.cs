using SOLID.DependencyInversion.domain;

namespace SOLID.DependencyInversion.infrastructure
{
    public class AvailabilityDaoImpl : IAvailability{
    
        public virtual bool IsAvailable() {
            //En realite il y aurait une dependance vers une base de donnéesS...
            return true; 
        }
    
    }
}
