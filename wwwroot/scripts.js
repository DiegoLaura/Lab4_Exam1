// scripts.js
document.addEventListener('DOMContentLoaded', function () {
    fetch('/Yelp')
        .then(response => response.json())
        .then(data => {
            const businessesContainer = document.getElementById('businesses-container');
            data.businesses.forEach(business => {
                const card = document.createElement('div');
                card.classList.add('business-card');
                card.innerHTML = `
                    <h3>${business.name}</h3>
                    <p>${business.location.address1}</p>
                    <p>${business.location.city}, ${business.location.state} ${business.location.zip_code}</p>
                    <p>Rating: ${business.rating}</p>
                `;
                businessesContainer.appendChild(card);
            });
        })
        .catch(error => console.error('Error fetching businesses:', error));
});
