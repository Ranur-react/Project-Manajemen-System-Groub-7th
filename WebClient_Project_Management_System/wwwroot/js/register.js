﻿function postEmployee() {
    let data = Object();

    data.Id = $("#id_emp").val();
    data.Firstname = $("#firstname").val();
    data.Lastname = $("#lastname").val();
    data.PhoneNumber = $("#phonenumber").val();
    data.BirthDate = $("#Birthdate").val();
    data.Email = $("#email").val();
    data.Gender = $("#inputGender").val();
    data.Password = $("#password").val();
    data.Role = $("#inputRole").val();
    data.Avatar = $("#avatar").val();


    console.log(data);

    console.log(JSON.stringify(data));

    $.ajax({
        url: "http://localhost:44376/api/accounts/register",
        type: "post",
        data:data
    }).done((result) => {
        console.log(result.status)
        console.log("Success");
        Swal.fire({
            title: 'Success!',
            text: "Data Successfuly Inserted",
            icon: 'Success',
            confirmButtonText: 'Cool'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Do you want to continue',
            icon: 'error',
            confirmButtonText: 'Back'
        })
    })
}

$("#formRegister").validate({
    rules: {
        id: {
            required: true
        },
        firstname: {
            required: true
        },
        lastname: {
            required: true
        },
        phonenumber: {
            required: true
        },
        birthdate: {
            required: true
        },
        email: {
            required: true
        },
        pass: {
            required: true
        },
        role: {
            required: true
        },


    },
    submitHandler: function (form) {
        postEmployee(); //request POST
    }
});