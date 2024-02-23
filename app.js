// Function to send SMS and save the last selected location to local storage
function sendMessage(userName, location) {
  const phoneNumber = '9086443621';
  const message = `${userName} has signed out to ${location}`;

  // Save the last selected location to local storage
  localStorage.setItem(`lastLocation_${userName}`, location);

  fetch('/app/SendSMS', {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json',
      },
      body: JSON.stringify({ Name: userName, Location: location }),
  })
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));
}

// Function to load the last selected location from local storage
function loadLastLocation(userName) {
  const lastLocation = localStorage.getItem(`lastLocation_${userName}`);

  // Set the dropdown value to the last selected location
  const dropdown = document.getElementById(`location${userName}`);
  if (dropdown) {
      dropdown.value = lastLocation || ''; // Set to the last location or empty string if not found
  }
}

// Call the loadLastLocation function for each user when the page loads
document.addEventListener('DOMContentLoaded', function() {
  loadLastLocation('Jeanlouie_Sam');
  loadLastLocation('Mariscal_Grace');
  loadLastLocation('Jimenez_Rosa');
});
