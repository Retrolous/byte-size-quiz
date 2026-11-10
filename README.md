# Byte-size Quiz: Computational Thinking Learning Platform

A Windows desktop app that teaches programming and computational thinking through three interactive challenges, with an admin side for tracking learner performance. Built solo as my AS Software Systems Development coursework, from requirements through to testing and evaluation.

## The three challenges

1. **Programming:** write real C# solutions in an embedded Monaco code editor (the engine behind VS Code). Code is compiled and run at runtime with Roslyn and Reflection, then checked against the expected output.
2. **Logic gates:** drag, drop and wire up gates to build circuits for a target output. A recursive evaluator checks the circuit.
3. **Puzzle game:** a top-down, timed puzzle with pushable boxes, rotating cogs and levels loaded from a text file, based off of Sokoban.

## Other highlights

- **Accounts and security:** registration with strong-password enforcement and PBKDF2-hashed passwords. User data lives in an encoded file, and admin accounts need a secret key.
- **Admin tools:** a staff menu to edit users and a leaderboard showing score totals, averages and top performers.
- **Game design:** randomised, file-driven questions, timers that affect scoring, skip and retry rules, and a Unix-terminal-inspired UI with a custom shutdown animation.
- **Responsive code execution:** user code runs on a separate thread so the UI never freezes.

## Tech used

C# · Windows Forms · WebView2 · Monaco Editor · Roslyn · file-based storage

## Process

32 documented requirements, storyboards revised from client feedback, full design documentation, white-box, unit, integration and system testing with documented corrective actions, and a written evaluation. The full write-up is in the PDF file.

*Note that version management was done internally, so no previous commits will be visible in the repository. Regardless, constant back-ups and incremental saves were conducted throughout the lifecycle to ensure no loss of data and/or broken code.*
