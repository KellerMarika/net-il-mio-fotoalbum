

function GetPhotos(queryText) {
    let photoTable = document.getElementById("photos-table");
    photoTable.innerHTML = ""; //svuoto
    axios.get('/api/Photo', {
        params: {
            queryText: queryText
        }
    }).then((resp) => {
        let photosList = resp.data;

        for (let i = 0; i < photosList.length; i++) {
            let photo = photosList[i];
            let tr = document.createElement("tr");

            let imgTd = document.createElement("td");
            let img = document.createElement("img");
            img.setAttribute("src", "~/img/" + photo.image);
            img.setAttribute("alt", photo.title);
            imgTd.appendChild(img);
            tr.appendChild(imgTd);

            let titleTd = document.createElement("td");
            titleTd.innerText = photo.title;
            tr.appendChild(titleTd);

            let descriptionTd = document.createElement("td");
            descriptionTd.innerText = photo.description;
            tr.appendChild(descriptionTd);

            let visibleTd = document.createElement("td");
            visibleTd.innerText = photo.visible;
            tr.appendChild(visibleTd);

            let categoriesTd = document.createElement("td");
            for (let j = 0; j < photo.categories.length; j++) {
                let category = photo.categories[j];
                let span = document.createElement("span");
                span.classList.add("px-1");
                span.innerText = category.name;
                categoriesTd.appendChild(span);
            }
            tr.appendChild(categoriesTd);

            photoTable.appendChild(tr);
        }
    }).catch((error) => {
        console.log(error);
    });
}

function SendMex() {
    const email = document.getElementById("mex-email").value;
    const text = document.getElementById("mex-text").value;
    const data = {
        Email: email,
        Text: text
    };

    axios.post('/api/Photo', data)
        .then((resp) => {
            console.log(resp);
        })
        .catch((error) => {
            console.log(error);
        });
}
