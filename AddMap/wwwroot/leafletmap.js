export function load_map(raw) {
    try {
        let parsedData;

        // Check if 'raw' is a valid JSON string or already an object
        if (typeof raw === "string") {
            parsedData = JSON.parse(raw);
        } else {
            parsedData = raw;
        }

        console.log("Parsed data:", parsedData);

        let map = L.map('map').setView({ lon: 7.45972, lat: 46.22925 }, 9);

        // Define the bounds using southwest and northeast coordinates
        const southWest = L.latLng(45.8000, 6.6000);
        const northEast = L.latLng(46.5000, 8.3000);
        const bounds = L.latLngBounds(southWest, northEast);

        // Set the max bounds of the map
        map.setMaxBounds(bounds);

        // Prevent the map from going outside the bounds
        map.on('drag', function () {
            map.panInsideBounds(bounds);
        });

        // Set a minimum zoom level
        map.setMinZoom(9);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
        }).addTo(map);

        // Define custom icons for each type of renewable energy
        const customIconSolarPanel = L.icon({
            iconUrl: '/ressources/solar-panel-svgrepo-com (1).svg',
            iconSize: [20, 20],
            iconAnchor: [10, 20],
            popupAnchor: [-3, -50],
        });

        const customIconWindmill = L.icon({
            iconUrl: '/ressources/windmill-mill-svgrepo-com.svg',
            iconSize: [20, 20],
            iconAnchor: [10, 20],
            popupAnchor: [-3, -50],
        });

        const customIconHydro = L.icon({
            iconUrl: '/ressources/water-tool-construction-work-repair-svgrepo-com (1).svg',
            iconSize: [20, 20],
            iconAnchor: [10, 20],
            popupAnchor: [-3, -50],
        });

        const customIconBiomass = L.icon({
            iconUrl: '/ressources/sprout-svgrepo-com.svg',
            iconSize: [20, 20],
            iconAnchor: [10, 20],
            popupAnchor: [-3, -50],
        });

        // Ensure the data is an array before proceeding
        if (Array.isArray(parsedData)) {
            parsedData.forEach(plant => {
                let latitude = plant.x;
                let longitude = plant.y;
                let icon;

                // Assign the icon based on the mainCategory
                switch (plant.subCategory) {
                    case 'Wasserkraft':
                        icon = customIconHydro;
                        break;
                    case 'Windenergie':
                        icon = customIconWindmill;
                        break;
                    case 'Photovoltaik':
                        icon = customIconSolarPanel;
                        break;
                    case 'Biomasse':
                        icon = customIconBiomass;
                        break;
                    default:
                        icon = customIconHydro; // Fallback icon
                }

                // Create a marker and add it to the map
                let marker = L.marker([latitude, longitude], {
                    icon: icon,
                    opacity: 0.9
                });

                // Add a popup or tooltip with details
                marker.bindPopup(`
                    <b>${plant.municipality ?? "N/A"}</b><br>
                    Address: ${plant.address ?? "N/A"}<br>
                    Post Code: ${plant.postCode ?? "N/A"}<br>
                    Canton: ${plant.canton ?? "N/A"}<br>
                    Beginning of Operation: ${plant.beginningOfOperation ?? "N/A"}<br>
                    Initial Power: ${plant.initialPower ?? "N/A"} kW<br>
                    Total Power: ${plant.totalPower ?? "N/A"} kW<br>
                    Category: ${plant.plantCategory ?? "N/A"}
                `);
                marker.addTo(map);
            });
        } else {
            console.error("Invalid data format: Expected an array.");
        }
    } catch (error) {
        console.error("Error in load_map function:", error);
    }

    return "";
}
