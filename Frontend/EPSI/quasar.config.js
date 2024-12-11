const { configure } = require('quasar/wrappers');
const path = require('path');

module.exports = configure(function () {
  return {
    boot: ['i18n'],

    css: ['app.css'],

    extras: ['roboto-font', 'material-icons'],

    build: {
      target: {
        browser: ['es2019', 'edge88', 'firefox78', 'chrome87', 'safari13.1'],
        node: 'node20',
      },

      vueRouterMode: 'hash',
      vitePlugins: [
        [
          '@intlify/vite-plugin-vue-i18n',
          {
            include: path.resolve(__dirname, './src/i18n/**'),
          },
        ],
        [
          'vite-plugin-checker',
          {
            vueTsc: {
              tsconfigPath: 'tsconfig.vue-tsc.json',
            },
            eslint: {
              lintCommand: 'eslint "./**/*.{js,ts,mjs,cjs,vue}"',
            },
          },
          { server: false },
        ],
      ],
    },

    devServer: {
      open: true,
    },

    framework: {
      config: {},
      plugins: [],
    },

    animations: [],

    ssr: {
      pwa: false,

      prodPort: 3000,

      middlewares: ['render'],
    },

    pwa: {
      workboxMode: 'generateSW',
      injectPwaMetaTags: true,
      swFilename: 'sw.js',
      manifestFilename: 'manifest.json',
      useCredentialsForManifestTag: false,
    },

    cordova: {},

    capacitor: {
      hideSplashscreen: true,
    },

    electron: {
      inspectPort: 5858,

      bundler: 'packager',

      packager: {},

      builder: {
        appId: 'inventory-webapp',
      },
    },

    bex: {
      contentScripts: ['my-content-script'],
    },
  };
});
