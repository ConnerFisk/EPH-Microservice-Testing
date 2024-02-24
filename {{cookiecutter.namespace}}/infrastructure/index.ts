import { AppService, getStackReferenceConfig } from '@clearfunction/pulumi-eph-resources';
import * as pulumi from '@pulumi/pulumi';

const stackConfig = getStackReferenceConfig();

let appSettings = [
  {
    name: 'SomeRandomKey__Blah',
    value: 'blah',
  },
  {
    name: 'WEBSITES_PORT',
    value: '8080',
  },
];

if (pulumi.getStack() === 'dev') {
  appSettings.push({ name: 'ASPNETCORE_ENVIRONMENT', value: 'Development' });
}

const service = new AppService('{{cookiecutter.app_service_name}}', {
  description: '{{cookiecutter.description}}',
  stackConfig,
  appSettings,
});

export const defaultHostName = service.appService.defaultHostName;
