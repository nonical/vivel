# Vivel core

## Useful information

- active drives are displayed based on users current location (30 km radius)

- user can apply for a drive if the following conditions are met:
    - currently has no pending donation requests (user can only have one pending request)
    - if the drive bloodtype matches the users blood type
        - if users bloodtype is verified (one donation was approved, or hospital staff added bloodtype to user), user can only apply for bloodtype matched drives
        - if users bloodtype is not yet verified he can apply for any drive
    - if there’s been atleast 3 months since the last donation

- notifications are sent in 5 cases:
    - successfully applied to donation
    - donation scheduled by hospital staff
    - donation approved
    - donation rejected
    - drive open in the vicinity (30 km radius)
    
- badges are awarded
    - every 5 donations
    - every urgent drive approved donation

## Dev Setup

### pre-commit

Python is required to run `pre-commit`, easiest way to get Python on Windows is to download it from the [Python website](https://www.python.org/downloads/).

After installing Python, ensure `pip` is working and install `pre-commit`:
```
pip install pre-commit
```

And then in the root project directory run the following command to install the pre-commit hooks:
```
pre-commit install
```
