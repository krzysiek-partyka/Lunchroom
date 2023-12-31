﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
        const lunchroomEncodedName = container.data("encodedName");
        
        container.append(
            `<div class="card border-secondary mb-3" style="max-width: 30rem;">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="card-header">${student.firstName} ${student.lastName} ${student.numberOfLunches}
                        <a href="/Lunchroom/${lunchroomEncodedName}/Student/${student.id}" class="btn btn-primary">Edit</a>
                    </div>
                    <div class="btn-group" role="group" aria-label="Button group">
                         <button type="button" class="btn btn-success" onclick="addLunch(${student.id})">Add Lunch</button>
                         <button type="button" class="btn btn-danger" onclick="removeLunch(${student.id})">Remove Lunch</button>
                    </div>
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
                container.html("There are no services for this Lunchroom")
            } else {
                RenderStudents(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}

function increaseValue() {
    var input = document.querySelector('input[name="NumberOfLunches"]');
    var currentValue = parseInt(input.value);
    input.value = currentValue + 1;
}

function decreaseValue() {
    var input = document.querySelector('input[name="NumberOfLunches"]');
    var currentValue = parseInt(input.value);
    if (currentValue > 0) {
        input.value = currentValue - 1;
    }
}

function addLunch(studentId) {

    $.ajax({
        url: `/Student/${studentId}/AddLunch`,
        type: 'POST',
        success: function (result) {

            LoadStudents()
            toastr["success"]("Lunch added succefully")
            
        },
        error: function () {

            toastr["error"]("Something went wrong")
        }
    });
}

function removeLunch(studentId) {

    $.ajax({
        url: `/Student/${studentId}/RemoveLunch`,
        type: 'POST',
        success: function (result) {

            LoadStudents()
            toastr["success"]("Lunch removed succefully")
            
        },
        error: function () {
            
            toastr["error"]("Something went wrong")
        }
    });
}



