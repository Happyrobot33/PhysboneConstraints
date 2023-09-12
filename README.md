# VPM Package Template

Starter for making Packages, including automation for building and publishing them.

Once you're all set up, you'll be able to push changes to this repository and have .zip and .unitypackage versions automatically generated, and a listing made which works in the VPM for delivering updates for this repositories custom packages.

## ▶ Getting Started

* Press [![Use This Template](https://user-images.githubusercontent.com/737888/185467681-e5fdb099-d99f-454b-8d9e-0760e5a6e588.png)](https://github.com/Happyrobot33/template-package/generate)
to start a new GitHub project based on this template.
  * Choose a fitting repository name and description.
  * Set the visibility to 'Public'. You can also choose 'Private' and change it later.
  * You don't need to select 'Include all branches.'
* Clone this repository locally using Git.
  * If you're unfamiliar with Git and GitHub, [visit GitHub's documentation](https://docs.github.com/en/get-started/quickstart/git-and-github-learning-resources) to learn more.
* Add the folder to Unity Hub and open it as a Unity Project.
* After opening the project, wait while the VPM resolver is downloaded and added to your project.
  * This gives you access to the VPM Package Maker and Package Resolver tools.

## 🚇 Migrating Assets Package
Full details at [Converting Assets to a VPM Package](https://vcc.docs.vrchat.com/guides/convert-unitypackage)

## Working on Your Package

* Delete the "Packages/com.vrchat.demo-template" directory or reuse it for your own package.
  * If you reuse the package, don't forget to rename it!
  * In order for the release automation to work, you should format your package name as `com.username.package-name`.
* Update the `.gitignore` file in the "Packages" directory to include your package.
  * For example, change `!com.vrchat.demo-template` to `!com.username.package-name`.
  * `.gitignore` files normally *exclude* the contents of your "Packages" directory. This `.gitignore` in this template show how to *include* the demo package. You can easily change this out for your own package name.
* Open the Unity project and work on your package's files in your favorite code editor.
* When you're ready, commit and push your changes.
* Once you've set up the automation as described below, you can easily publish new versions.

## Setting up the Automation

You'll need to make a change in [release.yml](.github/workflows/release.yml):
* Change the `packagePrefix` to the prefix of your package. For example, if your package is `com.vrchat.demo-template`, the prefix is `com`. If your package is `test.package`, the prefix is `test`.

You will also need to modify source.json to include some important information.
* Change the instances of `YOUR_GITHUB_NAME` to your Github username
* Change the instances of `REPO_NAME` to the name of your repository

Finally, go to the "Settings" page for your repo, then choose "Pages", and look for the heading "Build and deployment". Change the "Source" dropdown from "Deploy from a branch" to "GitHub Actions".

That's it!
Some other notes:
* We highly recommend you keep the existing folder structure of this template.
  * The root of the project should be a Unity project.
  * Your packages should be in the "Packages" directory.
* If you want to store and generate your web files in a folder other than "Website" in the root, you can change the `listPublicDirectory` item [here in build-listing.yml](.github/workflows/build-listing.yml#L17).

## 🎉 Publishing a Release

A release will be automatically built whenever you push changes to your main branch which update files in the package folder you specified in `release.yml`. The version specified in your `package.json` file will be used to define the version of the release. Tags will be based on the displayname of the package and the version number, and there will be a release for every individual custom package. it wont build a release for a package if there is no change in its package.json version number.

## 📃 Rebuilding the Listing

Whenever you make a change to a release - automatically publishing it, or manually creating, editing or deleting one, the [Build Repo Listing](.github/workflows/build-listing.yml) action will make a new index of all the releases available, and publish them as a website hosted fore free on [GitHub Pages](https://pages.github.com/). This listing can be used by the VPM to keep your package up to date, and the generated index page can serve as a simple landing page with info for your package. The URL for your package will be in the format `https://username.github.io/repo-name`.

## 🏠 Customizing the Landing Page

The action which rebuilds the listing also publishes a landing page. The source for this page is in `Website/index.html`. The automation system uses [Scriban](https://github.com/scriban/scriban) to fill in the objects like `{{ this }}` with information from the latest release's manifest, so it will stay up-to-date with the name, id and description that you provide there. You are welcome to modify this page however you want - just use the existing `{{ template.objects }}` to fill in that info wherever you like. The entire contents of your "Website" folder are published to your GitHub Page each time.

## Technical Stuff

You are welcome to make your own changes to the automation process to make it fit your needs, and you can create Pull Requests if you have some changes you think we should adopt.
