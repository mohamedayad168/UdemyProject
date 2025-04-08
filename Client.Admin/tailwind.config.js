/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts,scss}", // <- SCSS not needed unless you use classes in .scss
  ],
  // safelist: [
  //   { pattern: /.*/ }, // <- this forces IntelliSense to suggest ALL classes
  // ],
  theme: {
    extend: {},
  },
  plugins: [],
};
