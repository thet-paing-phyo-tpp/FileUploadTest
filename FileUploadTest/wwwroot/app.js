export function ShowMessage(message) {
    console.log(`timer: ${message}`);
}

export function UploadFile() {
    const fileInput = document.getElementById("file-input");

    fileInput.addEventListener("change", async (event) => {
        console.time("timer");

        const file = event.target.files[0];

        const formData = new FormData();
        formData.append("file", file);

        const response = await fetch("/api/UploadFile/Upload", {
            method: "POST",
            body: formData
        });

        if (!response.ok) {
            const text = await response.text();
            ShowMessage(text);
        } else {
            const data = await response.json();
            console.log(data);
        }

        console.timeEnd("timer");
    });
}