using System;

namespace ApptFinder;

public class Resource
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Appointment> Appointments { get; set; }

    public Resource(string name, DateTime startTime, DateTime endTime)
    {
        Name = name;
        StartTime = startTime;
        EndTime = endTime;
        Appointments = new List<Appointment>();
    }
}

public class Appointment
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Appointment(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
}

public class ApptFinder
{

   
        public List<DateTime> GetAvailableTimeSlots(Resource resource, TimeSpan duration, TimeSpan appointmentDuration)
        {
            // Create a list to store the available time slots
            var availableTimeSlots = new List<DateTime>();

            // Start with the resource's start time
            var currentTime = resource.StartTime;

            // Loop through the day, checking for available time slots
            while (currentTime < resource.EndTime)
            {
                // Check if the current time is available
                if (IsTimeSlotAvailable(resource, currentTime, appointmentDuration))
                {
                    // If it is, add it to the list of available time slots
                    availableTimeSlots.Add(currentTime);
                }

                // Increment the current time by the desired duration
                currentTime = currentTime.Add(duration);
            }

            // Return the list of available time slots
            return availableTimeSlots;
        }

        private bool IsTimeSlotAvailable(Resource resource, DateTime startTime, TimeSpan duration)
        {
            // Check each appointment to see if it conflicts with the desired time slot
            foreach (var appointment in resource.Appointments)
            {
                if (startTime + duration > appointment.StartTime && startTime < appointment.EndTime)
                {
                    // If there is a conflict, the time slot is not available
                    return false;
                }
            }

            // If there are no conflicts, the time slot is available
            return true;
        }
    
}



