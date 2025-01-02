import { useState, useEffect } from "react";
import "../ReservationForm.css";

const ReservationForm = () => {
  const [equipment, setEquipment] = useState([]);
  const [selectedMember, setSelectedMember] = useState("");
  const [selectedDate, setSelectedDate] = useState("");
  const [selectedTimeSlots, setSelectedTimeSlots] = useState([]);
  const [showPopup, setShowPopup] = useState(false);
  const [popupMessage, setPopupMessage] = useState("");

  const timeslots = Array.from({ length: 14 }, (_, i) => `${8 + i}:00`);

  useEffect(() => {
    const fetchEquipment = async () => {
      const response = await fetch(
        "http://localhost:5151/api/Equipment/GetAllAvailableEquipment"
      );
      const data = await response.json();

      const availableEquipment = data.map((equipment) => ({
        id: equipment.id,
        name: equipment.type.name,
        description: equipment.type.description,
      }));

      setEquipment(availableEquipment);
    };
    fetchEquipment();
  }, []);

  const handleTimeSlotChange = (slot, equipmentId) => {
    const existingSlot = selectedTimeSlots.find((s) => s.timeSlot === slot);

    if (existingSlot) {
      setSelectedTimeSlots(
        selectedTimeSlots.filter((s) => s.timeSlot !== slot)
      );
    } else {
      setSelectedTimeSlots([
        ...selectedTimeSlots,
        { timeSlot: slot, equipmentId },
      ]);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const reservation = {
      memberId: parseInt(selectedMember, 10),
      reservationDate: selectedDate,
      timeSlots: selectedTimeSlots.map((slot) => ({
        startTime: slot.timeSlot.padStart(5, "0") + ":00",
        equipmentId: parseInt(slot.equipmentId, 10),
      })),
    };

    console.log("Submitted Reservation:", JSON.stringify(reservation, null, 2));

    try {
      const response = await fetch(
        "http://localhost:5151/api/Reservation/AddReservation",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(reservation),
        }
      );

      const responseText = await response.text();

      if (!response.ok) {
        throw new Error("Error making the reservation: " + responseText);
      }

      const popupDetails = `
        Reservation Successful!
        - Member ID: ${selectedMember}
        - Date: ${selectedDate}
        - Time Slots: ${selectedTimeSlots
          .map(
            (slot) => `${slot.timeSlot} with Equipment ID: ${slot.equipmentId}`
          )
          .join(", ")}
      `;

      setPopupMessage(popupDetails);
      setShowPopup(true);

      setSelectedMember("");
      setSelectedTimeSlots([]);
      setSelectedDate("");
    } catch (error) {
      console.error("Error making the reservation:", error);
      setPopupMessage("Something went wrong while making the reservation.");
      setShowPopup(true);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <h2>You Move: Fitness</h2>

        <label htmlFor="member">Member ID:</label>
        <input
          type="number"
          id="member"
          value={selectedMember}
          onChange={(e) => setSelectedMember(e.target.value)}
          placeholder="Enter Member ID"
          required
        />

        <label htmlFor="date">Date:</label>
        <input
          type="date"
          id="date"
          value={selectedDate}
          onChange={(e) => setSelectedDate(e.target.value)}
          required
        />

        <label htmlFor="timeslot">Timeslots:</label>
        <div id="timeslot" className="timeslot-grid">
          {timeslots.map((slot) => (
            <div key={slot} className="timeslot-item">
              <strong>{slot}</strong>
              <select
                onChange={(e) =>
                  handleTimeSlotChange(slot, e.target.value)
                }
                value={
                  selectedTimeSlots.find((s) => s.timeSlot === slot)?.equipmentId || ""
                }
              >
                <option value="" disabled>
                  Select Equipment
                </option>
                {equipment.map((equip) => (
                  <option key={equip.id} value={equip.id}>
                    {equip.name}
                  </option>
                ))}
              </select>
            </div>
          ))}
        </div>

        <button type="submit">Reserve</button>
      </form>

      {showPopup && (
        <div className="popup">
          <div className="popup-content">
            <p>{popupMessage}</p>
            <button onClick={() => setShowPopup(false)}>Close</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default ReservationForm;
