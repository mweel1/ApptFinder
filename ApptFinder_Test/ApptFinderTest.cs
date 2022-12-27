using ApptFinder;
using System.Collections.Generic;

namespace ApptFinder_Test;

public class ApptFinderTest
{
    [Fact]
    public void FindAvailAppt()
    {

        var resource = new Resource("Conference Room 1", new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 1, 17, 0, 0));

        // Add some appointments to the resource's Appointments list
        resource.Appointments.Add(new Appointment(new DateTime(2022, 1, 1, 10, 0, 0), new DateTime(2022, 1, 1, 11, 0, 0)));
        resource.Appointments.Add(new Appointment(new DateTime(2022, 1, 1, 13, 0, 0), new DateTime(2022, 1, 1, 14, 00, 0)));
        resource.Appointments.Add(new Appointment(new DateTime(2022, 1, 1, 15, 0, 0), new DateTime(2022, 1, 1, 16, 0, 0)));

        // Create a Scheduler object
        var apptFinder = new ApptFinder.ApptFinder();

        // Get the available time slots at 15-minute intervals, each with a duration of 1 hour
        TimeSpan intervalDuration = new TimeSpan(0, 15, 0); // 15 minutes
        TimeSpan appointmentDuration = new TimeSpan(1); // 1 hour
        List<DateTime> availableTimeSlots = apptFinder.GetAvailableTimeSlots(resource, intervalDuration, appointmentDuration);

        // Print the available time slots
        Console.WriteLine("Available time slots:");

        var i = 0;
        foreach (var timeSlot in availableTimeSlots)
        {
            Console.WriteLine(timeSlot.ToString());
            i++;
        }

        Assert.Equal(i, 24);

    }
}
