import { useState, useEffect } from "react";
import "../ReservationForm.css";

const ReservationForm = () => {
  const [members, setMembers] = useState([]);
  const [equipment, setEquipment] = useState([]);
  const [selectedMember, setSelectedMember] = useState("");
  const [selectedEquipment, setSelectedEquipment] = useState("");
  const [selectedTimeSlot, setSelectedTimeSlot] = useState("");
  const [selectedDate, setSelectedDate] = useState("");
<<<<<<< HEAD
  const [showPopup, setShowPopup] = useState(false);
  const [popupMessage, setPopupMessage] = useState("");
=======
>>>>>>> parent of fd6ebdf (Front-end fitness)

  const timeslots = Array.from({ length: 10 }, (_, i) => `${12 + i}:00`);

  useEffect(() => {
    const fetchMembers = async () => {
        const response = await fetch("http://localhost:5151/api/Member/GetAllMembers");
        const data = await response.json();

        const formattedMembers = data.map((member) => ({
          id: member.id,
          name: `${member.firstName} ${member.lastName}`,
        }));

        setMembers(formattedMembers);
    };
    fetchMembers();
  }, []);

  useEffect(() => {
    const fetchEquipment = async () => {
      const response = await fetch("http://localhost:5151/api/Equipment/GetAllAvailableEquipment");
      const data = await response.json();
  
      const availableEquipment = data.map((equipment) => ({
        id: equipment.id,
        name: equipment.type.name,
        description: equipment.type.description,
      }));
      
      console.log("Available Equipment:", availableEquipment); 
      setEquipment(availableEquipment);
    };
    fetchEquipment();
  }, []);
  
  const handleSubmit = async (e) => {
    e.preventDefault();
<<<<<<< HEAD
  
    const reservation = {
      memberId: selectedMember,
      equipmentId: selectedEquipment,
      timeSlot: { startTime: `${selectedTimeSlot}:00` }, 
      reservationDate: selectedDate,
    };
  
    try {
      const response = await fetch("http://localhost:5151/api/Reservation/AddReservation", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(reservation),
      });
  
      const responseText = await response.text();
      console.log("Response text from back-end:", responseText);
  
      if (!response.ok) {
        throw new Error("Fout bij het maken van de reservering: " + responseText);
      }
  
      let result;
      try {
        result = JSON.parse(responseText);
      } catch {
        result = { message: responseText };
      }
  
      console.log("Reservering succesvol:", result);
  
      const reservedEquipment = equipment.find((e) => e.id === parseInt(selectedEquipment));
      setPopupMessage(
        `Reservering succesvol! Klantnummer: ${selectedMember}, Gereserveerde apparatuur: ${reservedEquipment?.name}.`
      );
      setShowPopup(true);
  
      setSelectedMember("");
      setSelectedEquipment("");
      setSelectedTimeSlot("");
      setSelectedDate("");
=======

    const reservation = {
        memberId: selectedMember,
        equipmentId: selectedEquipment,
        timeSlots: [
            { startTime: `${selectedTimeSlot}:00` },
        ],
        reservationDate: selectedDate,
    };

    try {
        const response = await fetch("http://localhost:5151/api/Reservation/AddReservation", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(reservation),
        });

        const responseText = await response.text();
        console.log("Response text from back-end:", responseText);

        if (!response.ok) {
            throw new Error("Fout bij het maken van de reservering.");
        }

        const result = JSON.parse(responseText);
        console.log("Reservering succesvol:", result);
>>>>>>> parent of fd6ebdf (Front-end fitness)
    } catch (error) {
        console.error("Fout bij het maken van de reservering:", error);
    }
<<<<<<< HEAD
  };  
=======
};
>>>>>>> parent of fd6ebdf (Front-end fitness)
  return (
    <form onSubmit={handleSubmit}>
      <h2>You Move: Fitness</h2>

      {/* Member field */}
      <label htmlFor="member">Member:</label>
      <select
        id="member"
        value={selectedMember}
        onChange={(e) => setSelectedMember(e.target.value)}
        required
      >
        <option value="" disabled>
          Select a member
        </option>
        {members.map((member) => (
          <option key={member.id} value={member.id}>
            {member.name}
          </option>
        ))}
      </select>
      {/* Equipment field */}
      <label htmlFor="equipment">Equipment:</label>
      <select
        id="equipment"
        value={selectedEquipment}
        onChange={(e) => setSelectedEquipment(e.target.value)}
        required
      >
        <option value="" disabled>
          Select equipment
        </option>
          {equipment.map((equipment) => (
            <option key={equipment.id} value={equipment.id}>
                {equipment.name}
            </option>
          ))}
      </select>
      {/* Date field */}
      <label htmlFor="date">Date:</label>
      <input
        type="date"
        id="date"
        value={selectedDate}
        onChange={(e) => setSelectedDate(e.target.value)}
        required
      />
      {/* Timeslot field */}
      <label htmlFor="timeslot">Timeslot:</label>
      <select
        id="timeslot"
        value={selectedTimeSlot}
        onChange={(e) => setSelectedTimeSlot(e.target.value)}
        required
      >
        <option value="" disabled>
          Select a timeslot
        </option>
        {timeslots.map((slot) => (
          <option key={slot} value={slot}>
            {slot}
          </option>
        ))}
      </select>
      {/* Submit button */}
      <button type="submit">Reserve</button>
    </form>
  );
};

export default ReservationForm;
