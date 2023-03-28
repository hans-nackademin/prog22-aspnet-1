﻿const textValidation = (target, minLength) => {
    if (target.value.length >= minLength) {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""
    } else {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = `must contain more then ${minLength} characters`
    }
}

const emailValidation = (target) => {
    const regEx = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    console.log(target.value)
}
const passwordValidation = (target) => { console.log(target.value) }


const validate = (event) => {
    switch (event.target.type) {
        case 'text':
            textValidation(event.target, 2)
            break

        case 'email':
            emailValidation(event.target)
            break

        case 'password':
            passwordValidation(event.target)
            break
    }
}