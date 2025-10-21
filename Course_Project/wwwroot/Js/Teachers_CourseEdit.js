let imageInpt = document.getElementById("imageInput");
let imagePrivewElem = document.getElementById("preview");


imageInpt.addEventListener("change", function (e) {
    const file = this.files[0];
    if (file) {
        imagePrivewElem.src = URL.createObjectURL(file);
    }
})

let videoInput = document.getElementById("videoInput");
let videoSelectBtn = document.getElementById("videoSelectBtn");
let uploadBtn = document.getElementById("uploadVideoBtn");
let deleteBtn = document.getElementById("deletSelectedVideoBtn");
let addVideoForm = document.getElementById("addVideoForm");
let videosList = document.getElementById("videosList");

let selectedFile = null;

let addVideoBtn = document.getElementById("addVideo");


addVideoBtn.addEventListener("click", function (e) {
    addVideoForm.classList.remove("d-none")
});

videoSelectBtn.addEventListener("click", function (e) {
    videoInput.click();
})


videoInput.addEventListener("change", function (e) {
    const file = videoInput.files[0];
    if (file) {
        selectedFile = file;
        videoSelectBtn.classList.add("d-none")
        deleteBtn.classList.remove("d-none");

        let labelDiv = document.createElement("div");

        let label = document.createElement("label");
        label.classList.add("control-label", "fw-bold");
        label.textContent = file.name;

        let videoDiv = document.createElement("div");

        let video = document.createElement("video");
        video.src = URL.createObjectURL(file);
        video.classList.add("w-100", "rounded-3")
        video.controls = true;

        videosList.appendChild(videoDiv);
        videosList.appendChild(labelDiv);
        labelDiv.appendChild(label);
        videoDiv.appendChild(video);

        uploadBtn.classList.remove("d-none");
        uploadBtn.addEventListener("click", uploadVideo);

        deleteBtn.addEventListener("click", function (e) {
            videoSelectBtn.classList.remove("d-none")
            deleteBtn.classList.add("d-none");
            uploadBtn.classList.add("d-none");
            videosList.innerHTML = "";
            videoInput.value = "";
            videoSelectBtn.focus();
        });

    } else {
        alert("MOZ")
        videoInput.value = "";
    }

});

async function uploadVideo() {
    if (!selectedFile) {
        alert("ویدیو انتخاب نشده!");
        return;
    }
    var formData = new FormData(addVideoForm);
    formData.set("VideoFile", selectedFile)

    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    formData.set("__RequestVerificationToken", token);

    const res = await fetch("/Teacher/Videos/Create", {
        method: 'POST',
        body: formData
    })

    const data = await res.json();
    if (!data.success) {
        console.error(data);
        alert("خطا در آپلود: " + (data.message || data.errors?.join(", ")));
        return;
    }
    alert("ویدیو با موفقیت آپلود شد!");
    location.reload();
}