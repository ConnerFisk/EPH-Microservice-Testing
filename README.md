# EPH Microservice - Cookie Cutter Template

🔥🔥🔥 Go [here to finish setting up your repository](../../issues/new?template=issue-setup-repository.yml&title=[SETUP]:+Setup+Your+Repository). 🔥🔥🔥

## Overview

This repository is a Cookiecutter template for creating a new EPH microservice repository.

## Issue Template Resources

- [Syntax for Issue Forms](https://docs.github.com/en/communities/using-templates-to-encourage-useful-issues-and-pull-requests/syntax-for-issue-forms)
- [Syntax for GitHub's form schema](https://docs.github.com/en/communities/using-templates-to-encourage-useful-issues-and-pull-requests/syntax-for-githubs-form-schema#input)
- [Configuring issue templates for your repository](https://docs.github.com/en/communities/using-templates-to-encourage-useful-issues-and-pull-requests/configuring-issue-templates-for-your-repository#creating-issue-forms)

## Cookiecutter Resources

- [Cookiecutter Docs](https://cookiecutter.readthedocs.io/en/stable/index.html)

## GitHub Actions plus Cookiecutter

- [Sample GitHub Template](https://github.com/stefanbuck/cookiecutter-template/)
- [Blog Post Explaining General Approach](https://stefanbuck.com/blog/repository-templates-meets-github-actions)

## Secret Notes

There is a GitHub organization secret named `REPO_SETUP_TOKEN` that is tied to a Personal Access Token (Classic) with `workflow` permission granted. It has a 90 day expiration, but the fix is to just have someone create a new PAT and update the secret value.
