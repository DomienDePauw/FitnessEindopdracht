using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Interfaces;
public interface IEquipmentRepository
{
    void AddEquipment(Equipment equipment);
    List<Equipment> GetAllAvailableEquipment();
    Equipment GetEquipmentById(int equipmentId);
    void UpdateEquipment(int equipmentId, Equipment updatedEquipment);
}
