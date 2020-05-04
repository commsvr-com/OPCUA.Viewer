# OPC Unified Architecture (UA) Viewer

`OPC UA Viewer` is a simple and easy OPC UA Client - a software tool to be used by developers, testers, integrators. It allows users to easily:

- connect to the server
- read data from the server
- browse address space
- and much more!

OPC UA Viewer is an ideal solution for testing of connection with the OPC UA Server using different communication protocols and using many different data transfer security modes. The software may be used as a library and engaged as a part in custom software to provide OPC UA connectivity.

## Features

- ability to connect to many servers at the same time
- ability to connect to the OPC UA Server using either binary streams that use TCP channel or using Web Services and HTTP protocol
- support for many different data transfer security types, e.g. using encrypted or non-encrypted communication, certificates
- ability to automate testing of the servers connections that are working in the network
- browsing of the address space structure exposed by the server using references interconnecting nodes
- filtering of particular reference types in the `Browse` view
- creating the subscription to monitor changes of values (support for different types of monitoring is available)
- read and write of values from/to variables
- storing and loading of communication sessions

## Contributing

I strongly encourage community participation and contribution to this project. First, please fork the repository and commit your changes there. Once happy with your changes you can generate a 'pull request'. Visit the [Contributing][Contributing] document to get more.

The `OPC UA Viewer` was member of the CommServer software family. The CommServer was written by CAS Lodz Poland. Now it is migrating to GitHub and publishing as the Open-source software (OSS). OSS is a type of computer software in which source code is released under a license in which the copyright holder grants users the rights to study, change, and distribute the software to anyone and for any purpose. The separate project [commsvr-com/migration2os][migration2os] is being used to manage the migration process of transferring multi-parts software from an on-premise repository to a set of GitHub loosely coupled repositories.

Further development of CommServer software will be carried out under a broader concept described in the following article

- [OPC UA Makes Machine-Centric Global Village Possible – Call for Sponsors][wordpress.sponsors]

In the article, there is a call to action initiative. Consider joining. To get more, visit the section `How to be involved`.

At the top of the repository main page, there is the `Watch` and `Star` buttons.  If you're interested in this project click on one to get notifications about any activity and progress. It will be also a signal for me to increase priority for planned work related to this repository.

## See also

- [Online Help][Help]
- [OPC UA Makes Machine-Centric Global Village Possible – Call for Sponsors][wordpress.sponsors]
- [commsvr-com/migration2os][migration2os]

[Contributing]: https://github.com/mpostol/.github/blob/master/CONTRIBUTING.md
[Help]:https://commsvr-com.github.io/Documentation/Help
[wordpress.sponsors]: https://mpostol.wordpress.com/2020/01/03/opc-ua-makes-machine-centric-global-village-possible-call-for-sponsors/
[migration2os]: https://github.com/commsvr-com/migration2os
