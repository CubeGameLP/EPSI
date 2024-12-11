module.exports = {
  root: true,

  parserOptions: {
    parser: require.resolve('@typescript-eslint/parser'),
    extraFileExtensions: ['.vue'],
  },

  env: {
    browser: true,
    es2021: true,
    node: true,
  },

  extends: [
    'eslint:recommended', // Grundregeln von ESLint
    'plugin:@typescript-eslint/recommended', // TypeScript-Regeln
    'plugin:vue/vue3-essential', // Vue3 spezifische Regeln
    'prettier', // Deaktiviert alle ESLint-Regeln, die mit Prettier kollidieren
    'plugin:vue/vue3-recommended', // Falls du Vue 3 nutzt
    'plugin:prettier/recommended', // Aktiviert Prettier als Plugin und Konfiguration
  ],

  plugins: ['@typescript-eslint', 'vue', 'prettier'],

  globals: {
    ga: 'readonly',
    cordova: 'readonly',
    __statics: 'readonly',
    __QUASAR_SSR__: 'readonly',
    __QUASAR_SSR_SERVER__: 'readonly',
    __QUASAR_SSR_CLIENT__: 'readonly',
    __QUASAR_SSR_PWA__: 'readonly',
    process: 'readonly',
    Capacitor: 'readonly',
    chrome: 'readonly',
  },

  rules: {
    '@typescript-eslint/no-explicit-any': 'error',
    'prefer-promise-reject-errors': 'off',
    quotes: ['warn', 'single', { avoidEscape: true }],
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/no-var-requires': 'off',
    'no-unused-vars': 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'vue/singleline-html-element-content-newline': 'off',
    'vue/multiline-html-element-content-newline': 'off',
    'linebreak-style': 'off',
    "eol-last": "off",
  },
};
