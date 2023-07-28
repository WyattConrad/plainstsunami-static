(() => {
    'use strict'
    console.log("headscript.js loaded");
    const storedTheme = localStorage.getItem('theme')

    const getPreferredTheme = () => {

        if (storedTheme) {
            console.log(storedTheme);
            return storedTheme
        }

        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light'
    }

    const setTheme = function (theme) {
        if (theme === 'auto' && window.matchMedia('(prefers-color-scheme: dark)').matches) {
            console.log("theme changed to auto or dark");
            document.documentElement.setAttribute('data-bs-theme', 'dark')
        } else {
            console.log("theme changed to light");
            document.documentElement.setAttribute('data-bs-theme', theme)
        }
    }

    setTheme(getPreferredTheme())

    const showActiveTheme = (theme, focus = false) => {
        const themeSwitcher = document.querySelector('#bd-theme')

        if (!themeSwitcher) {
            return
        }

        const themeSwitcherText = document.querySelector('#bd-theme-text')
        const activeThemeIcon = document.querySelector('.theme-icon-active')
        const btnToActive = document.querySelector(`[data-bs-theme-value="${theme}"]`)
        const checkOfActiveBtn = btnToActive.querySelector('.fa-check')

        document.querySelectorAll('[data-bs-theme-value]').forEach(element => {
            element.classList.remove('active')
            element.setAttribute('aria-pressed', 'false')
            element.querySelector('.fa-check').classList.add('d-none')
        })

        activeThemeIcon.classList.remove('fa-circle-half-stroke', 'fa-sun', 'fa-moon')
        checkOfActiveBtn.classList.remove('d-none')
        if (theme == "light") {
            console.log("theme is light");
            activeThemeIcon.classList.add('fa-sun')
        } else if (theme == "dark") {
            console.log("theme is dark");
            activeThemeIcon.classList.add('fa-moon')
        }
        else {
            activeThemeIcon.classList.add('fa-circle-half-stroke')
        }

        btnToActive.classList.add('active')
        btnToActive.setAttribute('aria-pressed', 'true')
        
        const themeSwitcherLabel = `${themeSwitcherText.textContent} (${btnToActive.dataset.bsThemeValue})`
        themeSwitcher.setAttribute('aria-label', themeSwitcherLabel)

        if (focus) {
            themeSwitcher.focus()
        }
    }

    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', () => {
        if (storedTheme !== 'light' || storedTheme !== 'dark') {
            setTheme(getPreferredTheme())
        }
    })

    window.addEventListener('DOMContentLoaded', () => {
        showActiveTheme(getPreferredTheme())

        document.querySelectorAll('[data-bs-theme-value]')
            .forEach(toggle => {
                toggle.addEventListener('click', () => {
                    const theme = toggle.getAttribute('data-bs-theme-value')
                    localStorage.setItem('theme', theme)
                    setTheme(theme)
                    showActiveTheme(theme, true)
                })
            })
    })
})()