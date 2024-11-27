using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDL;

namespace FitnessBL;

public class ReservationService
{
    private readonly FitnessContext _context;

    public ReservationService(FitnessContext context) 
    {
        _context = context;
    }



    //Mijn logica om een reservatie te maken 

    //Klanten kunnen deze toestellen reserveren, daarbij geven ze aan welk toestel ze wensen en wanneer (dag en tijdslot) dat ze dat wensen te gebruiken.
    //Een tijdslot is telkens 1 uur en bij een reservatie kan1 specifiek toestelmaximaal2 tijdsloten na elkaar worden gereserveerd. Je kan in totaal  ook  maximaal  4  tijdsloten  per  dag  gebruiken  om  te  reserveren.
    //We onderscheiden ochtendsessies tussen 8 en 12 (dus 4 slots), middagsessies vanaf 12h tot 18h en avondsessies van 18h tot 22h.
    //In totaal zijn er dus 14 slots op 1 dag.Een reservatie bevat de volgende info : •klantnummer, emailadres,
    //voor en achternaam datum voor elk tijdslot het gereserveerde toestelZorg er ook voor dat er enkel reservaties kunnen plaatsvinden in de toekomst (lijkt me evident) en maximaal 1 week op voorhand.
    //Het kan voorkomen dat een toestel stuk gaat en er onderhoud nodig is, dan moet dat toestel tijdelijk niet beschikbaar worden.
    //In dit geval kunnen de bestaande reservaties niet doorgaan, stel een gebruiksvriendelijke oplossing voor !
}
