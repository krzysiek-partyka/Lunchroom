// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const classroomNames = {
    0: "I",
    1: "II",
    2: "III",
    3: "IV",
    4: "V",
    5: "VI",
    6: "VII",
    7: "VIII"
}

const RenderStudents = (students, container) => {
    container.empty();

    for (const student of students) {
        const classroomLabel = classroomNames[student.classroomName];
        const editLink = container.data("editLink");
        container.append(
            `<div class="card border-secondary mb-3" style="max-width: 98rem;">
          <div class="d-flex justify-content-between align-items-center">
              <div class="card-header">${student.firstName} ${student.lastName} <a href="${editLink}" class="btn btn-primary">EditStudent</a></div>
            </div>
          <div class="card-body">
            <h5 class="card-title">${classroomLabel}</h5>
          </div>
        </div>`)
    }
}

const LoadStudents = () => {
    const container = $("#students")
    const lunchroomEncodedName = container.data("encodedName");

    $.ajax({
        url: `/Lunchroom/${lunchroomEncodedName}/GetStudent`,
        type: 'get',
        success: function (data) { 
            if (!data.length) {
                container.html("There are no services for this car workshop")
            } else {
                RenderStudents(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}


